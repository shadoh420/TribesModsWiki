"""Build the Tribes mod wiki: python build.py  ->  site/"""
import json, math, os, re, shutil
from html import escape as esc
from tscript import parse_mod, parse_text, strip_comments, _outside_functions

ROOT = os.path.dirname(os.path.abspath(__file__))
SRC, OUT = os.path.join(ROOT, 'sources'), os.path.join(ROOT, 'site')

MODS = [
    dict(id='base', title='Base Tribes', version='1.11', dirs=['base'], launch='(none — stock game)',
         author='Dynamix', era='1998–1999'),
    dict(id='renegades-classic', title='Renegades Classic', version='1.1c', dirs=['base', 'renegades-classic'],
         launch='-mod RenegadesClassic', author='Renegades Development Team', era='1999–2000', base='base'),
    # Renegades family: title/author/era/launch come from content/catalog.json; diffs are against Renegades Classic
    *[dict(id=i, title=t, version=v, dirs=['base', i], base='renegades-classic', group='Renegades variants') for i, t, v in [
        ('renegades', 'RenegadesMod', 'v8-20-2003'),  # skip list set below
        ('eliterenegades', 'Elite Renegades', '1.1b'),
        ('renegades-duel', 'Renegades Duel', ''),
        ('shifter-renegades', 'Shifter Renegades', ''),
        ('renegadez', 'Renegadez', '1.1'),
        ('ren2k', 'Ren2K', ''),
        ('ndg20', 'NDG Renegades', '2.0'),
    ]],
    # Ultra Renegades family. Each build is compared against its closest earlier relative, picked by era plus
    # the share of identical item datablocks; builds that share almost nothing with the others compare to base.
    *[dict(id=i, title=t, version='', dirs=['base', i], base=p, group=g) for g, rows in [
        ('Ultra Renegades', [
            ('ur2', 'Ultra Renegades 2', 'renegades-classic'),
            ('ur3-mayhem', 'UR3 Mayhem', 'ur2'),
            ('ur4', 'Ultra Renegades 4', 'ur3-mayhem'),
            ('ur-xl', 'UltraXL', 'ur3-mayhem'),
            ('ultra-mega-mod', 'Mega Renegades', 'ur4'),
            ('ur3-league', 'UR3 League', 'ur4'),
            ('anarchy-ur', 'UR3 vs Anarchy', 'ur3-league'),
            ('ultra-renegades-modmgt', 'Ultra Renegades Modmgt', 'ur2')]),
        ('Ultra Renegades VX', [
            ('ultra-renegades-vx5', 'Ultra Renegades VX5', 'base'),
            ('ultra-vx5-ix', 'VX5 IX', 'ultra-renegades-vx5'),
            ('ultra-renegades-jman', 'VX5 Jman', 'ultra-renegades-vx5'),
            ('ultra-vx5-god', 'VX5 GoD', 'ultra-renegades-vx5'),
            ('ultra-vx5-hunter', 'VX5 Hunter', 'ultra-renegades-vx5'),
            ('ultra-infinite', 'VX5 Infinite', 'ultra-vx5-hunter'),
            ('ultra-tribute', 'VX Tribute', 'ultra-infinite'),
            ('ultra-vxc', 'VX Combination (VXC)', 'ultra-renegades-vx5'),
            ('ultra-vxo', 'VXO', 'ultra-vxc'),
            ('ultra-vxe', 'VX Extreme (VXE)', 'ultra-vxo'),
            ('ultra-vxu', 'VXU', 'ultra-vxo'),
            ('ultra-vx6', 'Ultra Renegades VX6', 'base'),
            ('ultra-vx-elite', 'VX-Elite', 'ultra-vx6'),
            ('ultra-vx3', 'UltraVX3', 'vx3-a09'),
            ('ultra-ux', 'UltraXtreme UX', 'ultra-renegades-vx5')]),
        ('Other Ultra builds', [
            ('ultra-zx', 'Ultra-ZX Infinite', 'base'),
            ('ultra-gzhq', 'Ultra Renegades GZHQ', 'base'),
            ('ur-x', 'Ultra Renegades -X-', 'base'),
            ('ur-rx', 'Ultra Renegades RX', 'base'),
            ('ur-2004', 'Ultra Renegades 2004', 'base')]),  # predecessor of RX, shares little with earlier UR builds
        # filed under Ultra Renegades in the catalog, but built on other mods (BOP, HaVoC, Meltdown); stats only for now
        ('Related (not UR-based)', [
            ('ultra-bop', 'Ultra-BOP', 'base'),
            ('ultra-warfare', 'Ultra Warfare', 'base'),
            ('blur-of-insanity', 'Blur of Insanity', 'base'),
            ('meltdown-ultra', 'Meltdown Ultra', 'base')]),
        # Tribal God credits Plasmatic's Annihilation core but shares no item datablocks with it, so it compares to base
        ('Annihilation', [
            ('annihilation', 'Total Annihilation', 'base'),
            ('ultrannihilation', 'UltrAnnihilation', 'annihilation'),
            ('apteryx', 'Apteryx v2', 'annihilation'),
            ('annihilation-3', 'Annihilation 3', 'ann-3-2009-03-03'),
            ('vengeance', 'Annihilation Vengeance', 'ann-3-beta'),  # Dec 2004, on the Annihilation 3 Beta loader
            ('tribal-god-original', 'Tribal God (original, Apr 2003)', 'base'),
            ('utg-6-5', 'Ultra Tribal God 6.5 (Aug 2003)', 'tribal-god-original'),
            ('tribal-god', 'Tribal God', 'utg-6-5')]),  # matches the Ultra Tribal God 6.6 installer (Nov 2003)
        # Ultra Shifter Duel's stats sit closest to v1G, but its scripts are Shifter's (15 items differ vs 52 from v1G)
        ('Shifter', [
            ('shifter', 'Shifter', 'base'),
            ('shifter-bots', 'Shifter v1 with Bots (1999)', 'base'),
            ('starmod', 'STAR Mod', 'shifter-bots'),
            ('shifter-sg1', 'Shifter SG1', 'shifter'),
            ('shifter-xtreme', 'Shifter Xtreme', 'shifter'),
            ('shifter-v1g', 'Shifter HC (v1G)', 'shifter'),
            ('shifter-2k4', 'Shifter 2K4 (v0.8)', 'shifter-v1g'),
            ('shifter-2k5', 'Shifter 2K5', 'shifter-v1g'),
            ('shifter-k', 'ShifterK', 'shifterk-2003-08-09'),
            ('shifter-vx5duel', 'Ultra Shifter Duel', 'shifter'),
            ('shifter-v2', 'Shifter v2', 'shifter'),
            ('shifter-advanced', 'Shifter Advanced', 'shifter'),
            ('shifter-vsiyx', 'Shifter vSiyx', 'shifter'),
            ('shifter-famm', 'Shifter FAMM', 'shifter-advanced'),
            ('shifter-v1y-2002', 'Shifter v1Y (2002-12-06)', 'shifter'),
            ('shifter-v1y', 'Shifter v1Y (2004-11-27)', 'shifter-v1y-2002'),
            ('shifter-v1y-2007', 'Shifter v1Y (2007-10-24 Beta)', 'shifter-v1y'),
            ('shifter-v1gy', 'Shifter v1GY', 'shifter-v1g'),
            ('shifter-v1yxtreme', 'Shifter v1Y Xtreme', 'shifter-v1y-2002'),
            ('shifterx-v18h', 'ShifterX v18h', 'shifter'),
            ('shifterx-v19b', 'ShifterX v19b', 'shifterx-v18h'),
            ('shifterx-v20c', 'ShifterX v20c', 'shifterx-v19b')]),
        ('Classic & Base+', [
            ('base-plus', 'Dynamix Plus MOD', 'base'),
            ('enhanced-base', 'Enhanced Base', 'base'),
            ('ot', 'OldTribes', 'base'),
            ('bop', 'Balance of Power', 'base'),
            ('insomniax', 'Insomniax', 'base'),
            ('havoc', 'HaVoC', 'base'),
            ('minimod', 'MiniMod', 'base'),
            ('rb2', 'Reality Bites 2.0', 'minimod')]),
        ('Meltdown', [
            ('meltdown-classic', 'Meltdown Classic', 'base'),
            ('meltdown-2', 'Meltdown 2', 'meltdown-classic'),
            ('meltdown-hell', 'Meltdown Hell', 'meltdown-2'),
            ('meltdown-total-war', 'Meltdown Total War', 'meltdown-hell'),
            ('meltdown-x', 'Meltdown X', 'meltdown-hell'),
            ('armageddon', 'Armageddon', 'meltdown-2')]),
        ('Foundation & Apocalypse', [
            ('foundation', 'Foundation', 'base'),
            ('foundation-2', 'Foundation II', 'base'),
            ('apocalypse', 'Apocalypse Mod', 'base'),
            ('atf', 'ATF Mod', 'base'),
            ('gammy-mk2', 'GammY MK2', 'atf')]),
        ('Hybrid & Heavy Action', [
            ('novamorpher', 'NovaMorpher', 'base'),
            ('hybrid', 'Hybrid 2K4', 'base'),
            ('cybrid-2k5', 'Cybrid 2K5', 'ultra-vx-elite'),
            ('rampage', 'Rampage', 'base')]),
        ('Total Conversions', [
            ('5th-element', '5th Element', 'base'),
            ('dune', 'DUNE', 'base'),
            ('dbz', 'DBZ 3k', 'base'),
            ('starsiege', 'Starsiege', 'base'),
            ('starsiege-craft', 'Starsiege Craft', 'base'),
            ('gundam', 'Gundam Wing', 'starsiege-craft'),
            ('screaming-fist', 'Screaming Fist', 'base'),
            ('starwars', 'Star Wars TC', 'base'),
            ('swrpg', 'Star Wars RPG', 'base'),
            ('wwii-mod', 'WWII Mod', 'base')]),
        ('RPGs & Progression', [
            ('aeon', 'AEON RPG', 'base'),
            ('knights-16', 'Knights v1.6', 'base'),
            ('rmrpg', 'Red Moon RPG', 'base')]),
        ('Competitive & Duels', [
            ('base-duel', 'BaseDuel', 'base'),
            ('duel', 'Duel Tournament', 'base'),
            ('team-duel', 'Team Duel', 'base'),
            ('tribes-arena', 'Tribes Arena', 'base'),
            ('ultra-competition', 'Ultra Competition', 'ultra-renegades-vx5')]),
        ('Tactical & Realism', [
            ('delta-force', 'DeltaForce', 'base'),
            ('deltaairforce', 'Delta Air Force', 'delta-force'),
            ('hard-corps', 'Hard Corps', 'base'),
            ('hv-tactical', 'hvTactical', 'renegades-classic'),
            ('specialist', 'Specialist', 'base'),
            ('squadmod-alpha', 'SquadMod Alpha', 'base'),
            ('strategic-combat', 'Strategic Combat', 'tribal-combat'),
            ('swattactics', 'SWAT Tactics', 'base'),
            ('vip', 'VIP Assassination', 'base')]),
        ('Comedic & Sports', [
            ('football', 'Tribes Football', 'base'),
            ('football-1v1', 'Football 1vs1', 'football'),
            ('paintball', 'Paintball v2.6', 'base'),
            ('paintball-speed', 'Paintball v.Speed', 'base'),
            ('paintball-9beta', 'Paintball v9.0 Beta', 'paintball-speed'),
            ('paintball-rs', 'Paintball vRaPiD StYLe', 'paintball-9beta'),
            ('paintball-tactical', 'Paintball v.Tactical', 'base'),
            ('cocaine', 'Nappy Cocaine', 'renegades-classic'),
            ('rsp', 'Redneck Slag Pack', 'base'),
            ('sex-nc17', 'SEX mod NC17', 'base'),
            ('tribes-racer', 'Tribes Racer', 'base'),
            ('tsc', 'Tribes Snowboarding Circuit', 'base'),
            ('xfrisbee', 'Extreme Frisbee', 'base')]),
        ('Action & Mechanics', [
            ('420snipers', '420Snipers', 'base'),
            ('aaod', 'AAOD 1.6Ex', 'bop'),
            ('advanced-war', 'Advanced War', 'base'),
            ('alliance', 'Alliance Engine', 'base'),
            ('tiz19', 'TiZ v1.9', 'alliance'),
            ('ravenstorm', 'RavenStorm', 'alliance'),
            ('xk', 'XK Mod', 'alliance'),
            ('snipers-base', 'Snipers Base', 'alliance'),
            ('cnc-tribes', 'C&C Tribes V2', 'base'),
            ('anarchy', 'ANARCHY 2.0', 'renegades-classic'),
            ('insane', 'INSANE 1.0a', 'anarchy'),
            ('pantheon', 'Pantheon 1.02', 'insane'),
            ('phobiax-109', 'Phobiax 1.09', 'insomniax'),
            ('anathrax', "AnAThrax's Mod", 'base'),
            ('apollo11', 'Apollo 11', 'base'),
            ('asylum', 'Asylum 2.5', 'apollo11'),
            ('beginner-mod', 'Beginner Mod', 'base'),
            ('biowasteland', 'BioWasteland 7.5', 'shifter'),
            ('blitzkrieg', 'Blitzkrieg 1.0b', 'base'),
            ('chivalry', 'Chivalry v2.0', 'base'),
            ('skynet', 'SkyNet 1.0', 'base'),
            ('cisygy', 'CiSYGY PR1', 'skynet'),
            ('destroyer', 'Destroyer Mod', 'base'),
            ('devastator', 'Devastator 0.99', 'base'),
            ('genocide', 'Genocide v2R', 'base'),
            ('holocaust', 'Holocaust v3.5', 'meltdown-classic'),
            ('devious-land', 'DeviousLand 1.46', 'base'),
            ('retro', 'Retrogear 1.25b', 'devious-land'),
            ('dogfight', 'DogFight v1.5', 'base'),
            ('isn', 'ISN Rift 4.0a', 'base-plus'),
            ('eradication', 'Eradication 1.4', 'isn'),
            ('et-war', 'ET War', 'base'),
            ('extreme', 'Extreme', 'base'),
            ('orion', 'Orion Mod', 'base'),
            ('professional', 'Tribes Professional', 'orion'),
            ('fallout', 'Fallout Alpha', 'base'),
            ('gunstar', 'GunStar 0.5', 'base'),
            ('herchavoc', 'Herc Havoc', 'base'),
            ('hunters', 'Tribes Hunters', 'base'),
            ('hv-mechwarrior', 'hvMechWarrior 1.4', 'base'),
            ('hv-mechbot', 'HvMechBot', 'hv-mechwarrior'),
            ('ideal', 'Ideal Mod', 'base'),
            ('jester', 'JesterMOD v1', 'ultra-renegades-vx5'),
            ('mmsflight', 'MMSFlight', 'base'),
            ('modx', 'Mod X', 'base'),
            ('mortar-men', 'Mortar Men', 'base'),
            ('nappy', 'Nappy Mod', 'base'),
            ('nappy-builder', 'Nappy Builder', 'renegades-classic'),
            ('nappy-c-builder', 'Nappy C-Builder', 'nappy-builder'),
            ('netrunner', 'NetRunner', 'base'),
            ('nfs', 'Need For Speed', 'base'),
            ('nihility', 'NIHILITY 1.4.3', 'base'),
            ('omega-mod', 'Omega Mod', 'base'),
            ('proud-man-down', 'Proud Man Down', 'base'),
            ('r1', 'R1 v1.2', 'base'),
            ('s4l', 'Snipers For Life', 'base'),
            ('scout-skirmish', 'Scout Skirmish', 'thunderstruck'),
            ('shadow-10', 'SHaDoW v1.0', 'base'),
            ('shazbot-beta1', 'Shazbot Beta', 'base'),
            ('striker', 'Striker MOD', 'base'),
            ('tac', 'Team Aerial Combat', 'base'),
            ('talon', 'Talon Mod 2.2', 'base'),
            ('tantrum', 'Tribes Tantrum', 'base'),
            ('thieves', 'Thieves Mod', 'shifter'),
            ('thugwars', 'ThugWars', 'base'),
            ('thunderstruck', 'ThunderStruck', 'havoc'),
            ('top-gun', 'Top Gun', 'delta-force'),
            ('tribal-combat', 'Tribal Combat', 'base'),
            ('vehiclemod', 'VehicleMod', 'base-plus')]),
        # Alternate builds from Krogoth's File Library; parent = the previous build of the family by script dates
        ('Annihilation builds', [
            ('ann-1-00', 'Annihilation 1.00', 'base'),
            ('ann-1-34', 'Annihilation 1.34', 'ann-1-00'),
            ('ann-2-0-beta-0513', 'Annihilation 2.0 Beta (May 13, 2002)', 'ann-1-34'),
            ('ann-2-0-beta-0514', 'Annihilation 2.0 Beta (May 14, 2002)', 'ann-2-0-beta-0513'),
            ('ann-2-0-beta-0516', 'Annihilation 2.0 Beta (May 16, 2002)', 'ann-2-0-beta-0514'),
            ('ann-2-0-beta-0520', 'Annihilation 2.0 Beta (May 20, 2002)', 'ann-2-0-beta-0516'),
            ('ann-vag1', 'Annihilation vAG1', 'ann-2-0-beta-0520'),
            ('ann-3-beta', 'Annihilation 3 Beta (patched)', 'annihilation'),
            ('ann-3-2009-03-03', 'Annihilation 3 (March 2009)', 'ann-3-beta')]),
        ('Shifter builds', [
            ('shifter-1999-05-25', 'Shifter v1 (05-25-99)', 'base'),
            ('shifter-1999-05-27', 'Shifter v1 (05-27-99b)', 'shifter-1999-05-25'),
            ('shifter-1999-06-03', 'Shifter v1 (06-03-99)', 'shifter-1999-05-27'),
            ('shifter-1999-06-12', 'Shifter v1 (06-12-99)', 'shifter-1999-06-03'),
            ('shifter-1999-06-18', 'Shifter v1 (06-18-99)', 'shifter-1999-06-12'),
            ('shifter-1999-07-23', 'Shifter v1 (07-23-99)', 'shifter-1999-06-18'),
            ('shifter-1999-10-05', 'Shifter (10-05-99)', 'shifter-1999-07-23'),
            ('shifter-spoonbots', 'Shifter with SpoonBots', 'shifter-1999-10-05'),
            ('shifter-01', 'Shifter 01', 'shifter-1999-10-05'),
            ('shifter-1999-12-30', 'Shifter (12-30-99)', 'shifter-1999-10-05'),
            ('shifter-2000-01-10', 'Shifter v1 (01-10-2000)', 'shifter-1999-12-30'),
            ('shifter-2000-01-28', 'Shifter v1 (01-28-2000)', 'shifter-2000-01-10'),
            ('shifter-2000-03-18', 'Shifter v1 (03-18-2000)', 'shifter-2000-01-28'),
            ('shifter-2000-07-13', 'Shifter (07-13-2000)', 'shifter-2000-03-18'),
            ('shifter-2000-07-29', 'Shifter (07-29-2000 / 07-30-2000)', 'shifter-2000-07-13'),
            ('shifter-2000-07-30a', 'Shifter (07-30-2000-A)', 'shifter-2000-07-29'),
            ('shifter-2000-07-30b', 'Shifter (07-30-2000-B)', 'shifter-2000-07-30a'),
            ('shifter-2000-09-01', 'Shifter (09-01-2000)', 'shifter-2000-07-30b'),
            ('shifter-2000-09-08', 'Shifter (09-08-2000)', 'shifter-2000-09-01'),
            ('shifter-2001-04-20', 'Shifter (04-20-2001)', 'shifter'),
            ('shifter-v1g-2001-10-10', 'Shifter v1G (10-10-01)', 'shifter'),
            ('shifter-v1g-2002-02-14', 'Shifter v1G (02-14-02)', 'shifter-v1g-2001-10-10'),
            ('shifter-v1g-2002-06-19', 'Shifter v1G (06-19-02)', 'shifter-v1g'),
            ('shifter-v1g-2002-09-12', 'Shifter v1G (09-12-02)', 'shifter-v1g-2002-06-19'),
            ('shifter-v1g-2002-11-17', 'Shifter v1G (11-17-2002)', 'shifter-v1g-2002-09-12'),
            ('shifterk-2003-08-01', 'ShifterK (8-1-2003)', 'shifter-v1g-2002-11-17'),
            ('shifterk-2003-08-03', 'ShifterK (8-3-2003)', 'shifterk-2003-08-01'),
            ('shifterk-2003-08-08', 'ShifterK (8-8-2003)', 'shifterk-2003-08-03'),
            ('shifterk-2003-08-09', 'ShifterK (8-9-2003)', 'shifterk-2003-08-08'),
            ('shifter-2k4-v07', 'Shifter 2K4 v0.7 Beta', 'shifter-k'),
            ('shifter-2k4-v085', 'Shifter 2K4 v0.85 Beta', 'shifter-2k4'),
            ('shifter-2k5-v10', 'Shifter 2K5 v1.0', 'shifter-2k5')]),
        ('Hybrid (classic line)', [
            ('hybrid-setup', 'Hybrid (Mod Setup)', 'base'),
            ('hybrid-6-0a', 'Hybrid 6.0a', 'hybrid-setup'),
            ('hybrid-7-0', 'Hybrid 7.0', 'hybrid-6-0a'),
            ('hybrid-gold', 'Hybrid Gold', 'hybrid-7-0'),
            ('hybrid-x', 'Hybrid X', 'hybrid-gold'),
            ('hybrid-platinum', 'Hybrid Platinum', 'hybrid-x'),
            ('hybrid-se-beta', 'Hybrid SE Beta', 'hybrid-platinum'),
            ('hybrid-2k3', 'Hybrid 2K3 / Hybrid 3.0', 'hybrid-se-beta'),
            ('hybrid-0-1', 'Hybrid 0.1 (Pre-Beta)', 'hybrid-2k3'),
            ('arms2k4', 'Arms 2K4', 'hybrid-0-1')]),
        ('Ultra Renegades builds', [
            ('ur-u-renegades', 'Ultra Renegades (u_renegades)', 'base'),
            ('ur-0-86', 'Ultra Renegades 0.86', 'ur-u-renegades'),
            ('ur3-0-57', 'Ultra Renegades 3 v0.57', 'ur2'),
            ('ur3-0-64', 'Ultra Renegades 3 v0.64', 'ur3-0-57'),
            ('ur3-0-66b', 'Ultra Renegades 3 v0.66b', 'ur3-0-64'),
            ('ur3-mayhem-0-99c', 'UR3 Mayhem 0.99c', 'ur3-0-66b'),
            ('ur3-0-74', 'Ultra Renegades 3 v0.74', 'ur3-0-66b'),
            ('ur3-league-1-5', 'UR3 League 1.5', 'ur3-mayhem'),
            ('ur3-league-1-6', 'UR3 League 1.6', 'ur3-league-1-5'),
            ('ur3-league-1-7', 'UR3 League 1.7', 'ur3-league-1-6')]),
        ('Ultra VX builds', [
            ('vx3-plusmod', 'UltraVX3 (PlusMod)', 'base'),
            ('vx3-pooadmin', 'UltraVX3 (POOadmin)', 'vx3-plusmod'),
            ('vx3-notor', 'UltraVX3 (NOTOR)', 'vx3-pooadmin'),
            ('vx3-special', 'UltraVX3 Special', 'vx3-notor'),
            ('vx3-a08', 'UltraVX3 a08', 'vx3-special'),
            ('vx3-a09', 'UltraVX3 a09', 'vx3-a08'),
            ('vx3-ogl', 'UltraVX3 (OGL)', 'vx3-a09'),
            ('ultra-vxu-2003', 'Ultra Renegades VXU (Apr 2003)', 'ultra-vx3'),
            ('ultra-gzhq-beta', 'Ultra GZHQ Beta', 'base'),
            ('vx5-unlimited', 'VX5 Unlimited', 'ultra-renegades-vx5'),
            ('vxe-r06', 'VXE r06', 'ultra-vxo'),
            ('vxe-r07', 'VXE r07', 'vxe-r06'),
            ('vxe-r071', 'VXE r071', 'vxe-r07'),
            ('vxe-r072', 'VXE r072', 'vxe-r071'),
            ('vx5-infinite-1', 'VX5 Infinite 1', 'ultra-renegades-vx5'),
            ('vx5-infinite-2', 'VX5 Infinite 2', 'vx5-infinite-1'),
            ('vx5-god-2003', 'VX5 GoD (Nov 2003)', 'ultra-renegades-vx5'),
            ('vx5-infinite-3', 'VX5 Infinite 3', 'vx5-infinite-2'),
            ('vx5-infinite-4', 'VX5 Infinite 4', 'vx5-infinite-3'),
            ('vx5-infinite-5', 'VX5 Infinite 5', 'vx5-infinite-4'),
            ('vx5-hunter-2004', 'Hunter (VX5, May 2004)', 'ultra-vx5-hunter'),
            ('ur-tc', 'Ultra Renegades TC', 'ultra-infinite'),
            ('vx6-infinite-r1', 'VX6 Infinite r1.0', 'ultra-vx6'),
            ('vx5-infinite-6', 'VX5 Infinite 6 [VX]', 'vx5-infinite-5')]),
        ('Renegades (early)', [
            ('renegades-1-3', 'Renegades 1.3', 'base'),
            ('renegades-2-0', 'Renegades 2.0', 'renegades-1-3'),
            ('weapons-factory', 'Weapons Factory', 'renegades-2-0'),
            ('renegades-3-0', 'Renegades 3.0', 'renegades-2-0'),
            ('renegades-4-0b', 'Renegades 4.0b', 'renegades-classic'),
            ('renegades-4', 'Renegades 4 (renegades4)', 'renegades-4-0b'),
            ('renegades-5-0', 'Renegades 5.0', 'renegades-4'),
            ('renegades-6-0a', 'Renegades 6.0a', 'renegades-5-0')]),
        ('Other builds', [
            ('paintball-1-0', 'Paintball 1.0', 'base'),
            ('paintball-2-0', 'Paintball 2.0', 'paintball-1-0'),
            ('paintball-2-6-orig', 'Paintball 2.6 (unpatched)', 'paintball-2-0'),
            ('pb-tactical-2004', 'PB v.Tactical (Feb 2004)', 'paintball-tactical'),
            ('deltaforce-0-8', 'DeltaForce 0.8', 'base'),
            ('deltaforce-0-9b1', 'DeltaForce 0.9 beta 1', 'deltaforce-0-8'),
            ('deltaforce-0-9b2', 'DeltaForce 0.9 beta 2', 'deltaforce-0-9b1'),
            ('daf-server', 'Delta Air Force (server, 2007)', 'deltaairforce'),
            ('ssc-1-19', 'Starsiege Craft 1.19', 'base'),
            ('ssc-3-client', 'Starsiege Craft 3 (client side)', 'ssc-1-19'),
            ('ssc-3-server', 'Starsiege Craft 3 (server side)', 'ssc-3-client'),
            ('dbz-2000', 'DBZ (2000)', 'base'),
            ('base-duel-2000', 'Base Duel (2000)', 'base-duel'),
            ('tribes-racer-1999', 'Tribes Racer (1999)', 'base'),
            ('tribes-racer-retribution', 'Tribes Racer Retribution', 'tribes-racer-1999'),
            ('tribes-arena-2-1', 'Tribes Arena 2.1', 'base'),
            ('tribes-arena-2-2', 'Tribes Arena 2.2', 'tribes-arena-2-1'),
            ('tribes-arena-2-3', 'Tribes Arena 2.3', 'tribes-arena-2-2'),
            ('tribes-arena-3-0', 'Tribes Arena 3.0', 'tribes-arena'),
            ('minimod-0-3', 'MiniMod 0.3', 'base'),
            ('minimod-0-6-bare', 'MiniMod 0.6 (Bare)', 'minimod-0-3'),
            ('minimod-0-7', 'MiniMod 0.7', 'minimod-0-6-bare'),
            ('vip-2000', 'VIP (Feb 2000)', 'base'),
            ('vip-1-3', 'VIP 1.3', 'vip-2000'),
            ('renegades-duel-2002', 'Renegades Duel (2002)', 'renegades-duel'),
            ('dogfight-beta', 'DogFight Beta', 'base'),
            ('dogfight-2002-03', 'DogFight (Mar 2002)', 'dogfight-beta'),
            ('dogfight-1-0', 'DogFight 1.0', 'dogfight-2002-03'),
            ('ixtribes-06b', 'IXTribes 0.6b', 'base'),
            ('insomniax-0-8', 'Insomniax 0.8', 'ixtribes-06b'),
            ('insomniax-0-9a', 'Insomniax 0.9a', 'insomniax-0-8'),
            ('insomniax-0-9b', 'Insomniax 0.9b', 'insomniax-0-9a'),
            ('havoc-1-55', 'HaVoC 1.55', 'base'),
            ('havoc-1-59c', 'HaVoC 1.59c', 'havoc-1-55'),
            ('rampage-1-7', 'RaMpAgE 1.7', 'base'),
            ('sexmod-2', 'Sex Mod 2', 'base'),
            ('sexxx', 'SeXxX', 'sexmod-2'),
            ('sexmod-3', 'Sex Mod 3', 'sexxx'),
            ('nfs-v1', 'Need For Speed v1', 'base'),
            ('nfs-1999-06', 'Need For Speed (Jun 1999)', 'nfs-v1'),
            ('eradication-1-3', 'Eradication 1.3', 'isn'),
            ('rsp-1-17', 'RSP 1.17 (with Mission Score)', 'base'),
            ('rsp-1-18', 'RSP 1.18', 'rsp-1-17'),
            ('ultra-competition-1-0', 'Ultra Competition 1.0', 'ultra-renegades-vx5'),
            ('football-kitty', 'Football (Kitty)', 'football'),
            ('football-1v1-1-0', 'Football 1-on-1 Duel Server 1.0', 'football'),
            ('football-gsl', 'GSL Football Mod', 'football-1v1'),
            ('football-tasermod', 'Football Tasermod', 'football'),
            ('reality-bites-1-01', 'Reality Bites 1.01', 'minimod'),
            ('reality-bites-1-42', 'Reality Bites 1.42', 'reality-bites-1-01'),
            ('meltdown-2-15', 'Meltdown 2.15', 'meltdown-classic'),
            ('meltdown-ultra-2-32', 'Meltdown Ultra 2.32 (2-25-03)', 'meltdown-total-war'),
            ('meltdown-ultra-2-33-may', 'Meltdown Ultra 2.33 (May 2003)', 'meltdown-ultra-2-32'),
            ('meltdown-x-covert-ops', 'Meltdown X: Covert Ops (Premonition / Final Chapter v3.0)', 'meltdown-hell'),
            ('genocide-1b', 'Genocide 1b', 'base'),
            ('thugwars-1999', 'ThugWars (1999)', 'base'),
            ('blur-of-insanity-2002', 'Blur of Insanity (Nov 2002)', 'base'),
            ('scout-skirmish-2002', 'Scout Skirmish (Nov 2002)', 'thunderstruck'),
            ('nappy6', 'Nappy 6', 'nappy'),
            ('nappy6-beta', 'Nappy 6 Beta', 'nappy'),
            ('nihility-1-3-1', 'NIHILITY 1.3.1', 'base'),
            ('nihility-1-4-1', 'NIHILITY 1.4.1', 'nihility-1-3-1'),
            ('nihility-1-4-2', 'NIHILITY 1.4.2', 'nihility-1-4-1'),
            ('anarchymod', 'Anarchy (anarchymod)', 'renegades-classic')]),
    ] for i, t, p in rows],
]
_EXTRA_META = {
    'shifter-2k4': dict(version='v0.8', author='ParoXsitiC (assisted by Kill(--), Gonzo, Grey & Czar)', era='2004', launch='-mod shifter2K4'),
    'shifter-v2': dict(version='2001-05-14', author='Shifter Community (archive)', era='May 2001', launch='-mod Shifter'),
    'shifter-advanced': dict(version='2001-08-19 (unreleased)', author='Yukichigai', era='Aug 2001', launch='-mod Shifter'),
    'shifter-vsiyx': dict(version='2001-10-10', author="Siyx's Shifter Server (based on Shifter v1 2000-07-30b)", era='Oct 2001', launch='-mod Shifter'),
    'shifter-famm': dict(version='2002-02-19', author='Yukichigai (Fallen Angels / Multi Mayhem)', era='Feb 2002', launch='-mod Shifter_v1Y'),
    'shifter-v1y-2002': dict(version='2002-12-06', author='Yukichigai', era='Dec 2002', launch='-mod Shifter_v1Y'),
    'shifter-v1y': dict(version='2004-11-27', author='Yukichigai', era='Nov 2004', launch='-mod Shifter_v1Y'),
    'shifter-v1y-2007': dict(version='2007-10-24 Beta', author='Yukichigai', era='Oct 2007', launch='-mod Shifter_v1Y'),
    'shifter-v1gy': dict(version='2002-12-28 (unreleased)', author='Yukichigai (based on Shifter v1G)', era='Dec 2002', launch='-mod Shifter_v1GY'),
    'shifter-v1yxtreme': dict(version='2004-09-12', author='Yukichigai', era='Sep 2004', launch='-mod Shifter_v1YXtreme'),
    'shifterx-v18h': dict(version='v18h', author='ShifterX Team', era='Sep 2002', launch='-mod ShifterX'),
    'shifterx-v19b': dict(version='v19b', author='ShifterX Team', era='Jun 2003', launch='-mod ShifterX'),
    'shifterx-v20c': dict(version='v20c', author='ShifterX Team', era='Mar 2004', launch='-mod ShifterX'),
}
for _m in MODS:
    if _m['id'] in _EXTRA_META:
        _m.update(_EXTRA_META[_m['id']])
MODS[[m['id'] for m in MODS].index('ultra-warfare')]['entry'] = 'Ultra_Warfare'  # its server script is renamed
MODS[[m['id'] for m in MODS].index('minimod')]['entry'] = 'MiniMod'
MODS[[m['id'] for m in MODS].index('minimod-0-3')]['entry'] = 'MiniMod'
MODS[[m['id'] for m in MODS].index('minimod-0-7')]['entry'] = 'MiniMod-v07'
MODS[[m['id'] for m in MODS].index('alliance')]['entry'] = 'serverAlliance'
# VX5's vxmode()/vxDIFmode() let admins swap profile (OGL, NOTOR) and difficulty (MEDIUM, HARD) at runtime;
# the default is UltraVX5.cs + UltraVX5_EASY.cs, so the alternates don't count toward the wiki's stats.
for _m in MODS:
    if _m['id'] in ('ultra-renegades-vx5', 'ultra-renegades-jman', 'ultra-tribute'):
        _m['skip'] = ['UltraVX5_OGL', 'UltraVX5_NOTOR', 'UltraVX5_MEDIUM', 'UltraVX5_HARD']
_CATALOG = {e['id']: e for e in json.load(open(os.path.join(os.path.dirname(os.path.abspath(__file__)), 'content', 'catalog.json'), encoding='utf-8'))}
MODS[2]['skip'] = ['Elite', 'EliteRenegades', 'RenX', 'reload']  # RenegadesMod's admin-switchable modes (renmode())
for _m in MODS:
    for _k in ('author', 'era', 'launch'):
        _m.setdefault(_k, _CATALOG.get(_m['id'], {}).get(_k, ''))

CATS = [  # (slug, title, inventory heading)
    ('armors', 'Armors', 'aArmor'),
    ('weapons', 'Weapons', 'bWeapons'),
    ('packs', 'Packs', 'cBackpacks'),
    ('deployables', 'Deployables', 'dDeployables'),
    ('misc', 'Grenades, Mines & Misc', 'eMiscellany'),
    ('ammo', 'Ammunition', 'xAmmunition'),
    ('vehicles', 'Vehicles', 'aVehicle'),
    ('other', 'Other Gear', None),
    ('base-assets', 'Base Assets', None),
]
CAT_TITLE = {c[0]: c[1] for c in CATS}
DEPLOYED_TYPES = {'TurretData', 'SensorData', 'StaticShapeData', 'MineData', 'FlierData', 'MoveableData'}
# Mods invent their own shop headings ("TWeapons", "LTurretsVX", "kForce Fields", "fDeployable Weapons"...);
# the first letter only sorts the list, so match on the words. First hit wins.
HEADING_WORDS = [('deploy', 'deployables'), ('turret', 'deployables'), ('force field', 'deployables'), ('sensor', 'deployables'),
                 ('armor', 'armors'), ('vehicle', 'vehicles'), ('weapon', 'weapons'), ('ammo', 'ammo'), ('ammunition', 'ammo'),
                 ('pack', 'packs'), ('misc', 'misc'), ('grenade', 'misc')]

def heading_cat(head):
    if not head: return None
    exact = next((c for c, _, h in CATS if h and head == h), None)
    words = head[1:].lower() if head[1:2].isupper() else head.lower()
    return exact or next((c for w, c in HEADING_WORDS if w in words), 'other')
WEAPON_TYPE = {0: 'Single shot', 1: 'Spinning (auto)', 2: 'Sustained beam', 3: 'Disc (spin-up)'}
SKIP_FIELD = re.compile(r'^(animData|[rl]FootSounds|footPrints|sfx|sound|.*Sound(Id)?$|shadowDetailMask|validate|mapFilter|mapIcon|damageSkinData|debrisId|lightType|lightRadius|lightTime|lightColor|box|sequenceSound|bulletHoleIndex|expRandCycle|_)', re.I)


# ---------------------------------------------------------------- data
_TOP_EXTRAS = {
    'tribes-arena': ['arena.cs'],
    'xfrisbee': ['frisbee.cs'],
    'tribes-racer': ['TribesRacer.cs'],
    'duel': ['TDArena.cs', 'TDMain.cs'],
    'team-duel': ['TDArena.cs', 'TDMain.cs'],
    'insane': ['Insane.cs'],
    'pantheon': ['Pantheon.cs'],
    'ideal': ['Ideal.cs'],
    'omega-mod': ['Omega.cs'],
    **{i: ['TribesRacer.cs'] for i in ('tribes-racer-1999', 'tribes-racer-retribution')},
    **{i: ['arena.cs'] for i in ('tribes-arena-2-1', 'tribes-arena-2-2', 'tribes-arena-2-3', 'tribes-arena-3-0')},
    **{i: ['VIP.cs'] for i in ('vip-2000', 'vip-1-3')},
    'base-duel-2000': ['DuelMOD.cs'],
    'minimod-0-6-bare': ['MiniMod-v06.cs'],
    'football-1v1-1-0': ['fb1vs1mod.cs'],
}

class Mod:
    def __init__(self, m):
        self.__dict__.update(m)
        self.blocks, self.globs, self.scal, self.funcs = parse_mod([os.path.join(SRC, d) for d in m['dirs']], m.get('skip', ()), m.get('entry', 'server'))
        self.lb = {k.lower(): v for k, v in self.blocks.items()}
        self.g = {}
        for k, v in self.globs.items():
            d = self.g.setdefault(k.lower(), {})
            for kk, vv in v.items():
                d[kk.lower()] = vv
        self.s = {k.lower(): v for k, v in self.scal.items()}
        for rel in _TOP_EXTRAS.get(m['id'], ()):
            p_ex = os.path.join(SRC, m['dirs'][-1], rel)
            if os.path.isfile(p_ex):
                raw = _outside_functions(strip_comments(open(p_ex, encoding='latin-1').read()))
                _, eg, es, _ = parse_text(raw)
                for k, v in eg.items():
                    d = self.g.setdefault(k.lower(), {})
                    for kk, vv in v.items():
                        d[kk.lower()] = vv
                for k, v in es.items():
                    self.s[k.lower()] = v
        if m['id'] == 'hunters':
            p_fh = os.path.join(SRC, m['dirs'][-1], 'FlagHunter.cs')
            if os.path.isfile(p_fh):
                for b_item in re.findall(r'\$FlagHunter::banList\[\d+,\s*type\]\s*=\s*"([^"]+)"', open(p_fh, encoding='latin-1').read(), re.I):
                    self.g.setdefault('invlist', {})[b_item.lower()] = 0
                    self.g.setdefault('remoteinvlist', {})[b_item.lower()] = 0
        p = os.path.join(ROOT, 'content', m['id'] + '.json')
        self.content = json.load(open(p, encoding='utf-8')) if os.path.exists(p) else {}
        self.items = {}  # page name -> dict(name, cat, title)
        self._index()

    def ban_status(self, it):
        """Return 'banned', 'main-only', 'remote-only', or None from $InvList / $RemoteInvList / $TeamItemMax."""
        n, cat = it['name'], it['cat']
        if cat == 'base-assets': return None
        tm = self.glob('TeamItemMax', n)
        if tm == 0: return 'banned'
        inv = self.glob('InvList', n)
        rinv = self.glob('RemoteInvList', n)
        if inv == 0 and rinv in (0, None) and cat != 'ammo': return 'banned'
        if inv in (1, True) and rinv == 0: return 'main-only'
        if inv == 0 and rinv in (1, True): return 'remote-only'
        return None

    def block(self, name):
        return self.lb.get(str(name).lower()) if name else None

    def weapon_proj(self, name, img):
        """The image's projectileType, else the $WeapProjectile[weapon] table DUNE's Weapon::onFire spawns from,
        else the first Projectile::spawnProjectile("X", ...) in the image's onFire (Annihilation 3 / Vengeance)."""
        if not img: return None
        p = self.block(img.get('projectileType')) or self.block(self.glob('WeapProjectile', name))
        if p: return p
        m = re.search(r'Projectile::spawnProjectile\(\s*"?(\w+)"?\s*,', self.funcs.get((img['_name'].lower(), 'onfire'), ''), re.I)
        return self.block(m.group(1)) if m else None

    def glob(self, table, *keys):
        return self.g.get(table.lower(), {}).get(','.join(str(k).lower() for k in keys))

    def num(self, v):
        """Resolve 'price = $RemoteInvEnergy + 200' style values."""
        if isinstance(v, (int, float)) or v is None: return v
        expr = re.sub(r'\$(\w+(?:::\w+)*)', lambda m: str(self.s.get(m.group(1).lower(), 0)), str(v))  # undefined globals are "" (0) in-game
        if re.fullmatch(r'[\d\s.+\-*/()]+', expr):
            try: return eval(expr)
            except Exception: pass
        return v

    def _index(self):
        for b in self.blocks.values():
            if b['_type'] != 'ItemData': continue
            head = str(b.get('heading', ''))
            m = re.fullmatch(r'\$(\w+)\[\s*"?(\w+)"?\s*\]', head)  # Ren2K: heading = $InvHead[ihArm]
            if m: head = str(self.glob(m.group(1), m.group(2)) or '')
            elif head.startswith('$'): head = str(self.s.get(head[1:].lower(), ''))
            cat = heading_cat(head)
            if not cat and b.get('heading'): cat = 'other'
            if cat == 'other':  # unrecognised heading: fall back on the item's class
                cat = {'backpack': 'packs', 'weapon': 'weapons', 'ammo': 'ammo', 'armor': 'armors', 'vehicle': 'vehicles'}.get(str(b.get('className', '')).lower(), 'other')
            if cat: self.items[b['_name']] = dict(name=b['_name'], cat=cat, title=b.get('description', b['_name']), heading=head[1:] if head[1:2].isupper() else head)
        deployed = {d.lower() for it in list(self.items.values()) for d in self.deploys(it['name'])}
        for b in self.blocks.values():
            t, n = b['_type'], b['_name']
            if n.lower() in deployed: continue
            if t in ('TurretData', 'SensorData') or (t == 'StaticShapeData' and b.get('className') in ('Station', 'Generator') and 'maxDamage' in b):
                self.items[n] = dict(name=n, cat='base-assets', title=b.get('description', n))

    def deploys(self, name):
        out = []
        for (ns, fn), body in self.funcs.items():
            if ns != name.lower(): continue
            found = [m.group(1) for m in re.finditer(r'newObject\(\s*"[^"]*"\s*,\s*"?\w+"?\s*,\s*"?(\w+)"?', body)]
            # helper calls like Item::deployShape(..) / Turret::deployShape(..) (Ren2K): any deployable datablock named in the call
            for call in re.findall(r'\w+::deployShape\(([^;]*)', body):
                found += [w for w in re.findall(r'\b\w+\b', call) if (self.block(w) or {}).get('_type') in DEPLOYED_TYPES]
            for d in found:
                b = self.block(d)
                if b and d.lower() != name.lower() and b['_name'] not in out: out.append(b['_name'])
        return out

    def in_cat(self, cat):
        return [i for i in self.items.values() if i['cat'] == cat]

    def armors(self):
        """[(armor item, male PlayerData, female PlayerData)] in inventory order."""
        res = []
        for it in self.in_cat('armors'):
            m = self.glob('ArmorType', 'Male', it['name']); f = self.glob('ArmorType', 'Female', it['name'])
            res.append((it, self.block(m), self.block(f) if f and str(f).lower() != str(m).lower() else None))
        return res

    def own_text(self, name):
        return self.content.get('items', {}).get(name) or next((v for k, v in self.content.get('items', {}).items() if k.lower() == name.lower()), {})

    def text(self, name):
        """Own write-up, else the nearest ancestor's when this item's scripts are unchanged (marked 'inherited').
        If the stats changed anywhere along the way the text is marked 'stale': numbers or details may not apply."""
        t = self.own_text(name)
        if t or not getattr(self, 'base', None): return t
        P = BY_ID[self.base]
        if self.changed.get(name, 'stats') != 'stats': return {}
        pt = P.text(name)
        if not pt: return {}
        return dict(pt, inherited=pt.get('inherited', P), stale=pt.get('stale') or name in self.changed)


def norm(s): return re.sub(r'\s+', '', s or '').lower()

def changed(M, P):
    """Items M adds, renames, re-stats or re-scripts relative to parent mod P."""
    def related(X, name):
        b = X.block(name); out = [b]
        img = X.block(b.get('imageType'))
        if img: out += [img, X.weapon_proj(name, img)]
        return [x for x in out if x]
    def fns(X, name):
        # the item's own scripts plus those of its image, projectile and anything it deploys
        ns = {name.lower(), name.lower() + 'image'} | {b['_name'].lower() for b in related(X, name)} | {d.lower() for d in X.deploys(name)}
        return {k: norm(v) for k, v in X.funcs.items() if k[0] in ns}
    res = {}
    for name, it in M.items.items():
        if it['cat'] == 'base-assets': continue
        if name not in P.items:
            res[name] = 'new'; continue
        why = []
        if it['title'] != P.items[name]['title']: why.append('renamed')
        for a in related(M, name):
            b = P.block(a['_name'])
            skip_k = ('_file', 'validateShape', 'validateMaterials')
            if not b or {k: v for k, v in a.items() if k not in skip_k} != {k: v for k, v in b.items() if k not in skip_k}:
                why.append('stats'); break
        if fns(M, name) != fns(P, name): why.append('scripts')
        if why: res[name] = '+'.join(why)
    return res


def fmt(v):
    if v is None: return '—'
    if isinstance(v, float): return f'{v:.4g}'
    return str(v)

def dtype(v):
    if v in (None, ''): return '—'
    s = re.sub(r'^\$|damagetype$', '', str(v), flags=re.I)
    return s[:1].upper() + s[1:]

def slug(name): return name.lower()

def link(name, label=None, mod=None, prefix=''):
    return f'<a href="{prefix}{slug(name)}.html">{esc(label or name)}</a>'


# ---------------------------------------------------------------- html shell
CSS_HREF = '../style.css'

def shell(title, body, mod=None, crumbs=(), depth=1):
    up = '../' * depth
    nav, group = [], None
    for m in MODEL:
        if getattr(m, 'group', None) != group:
            group = getattr(m, 'group', None)
            nav.append(f'</ul><h4>{esc(group)}</h4><ul>')
        cur = ' class="cur"' if mod is m else ''
        nav.append(f'<li><a{cur} href="{up}{m.id}/index.html">{esc(m.title)}</a>')
        if mod is m:
            nav.append('<ul>' + ''.join(f'<li><a href="{up}{m.id}/{c}.html">{t}</a></li>' for c, t, _ in CATS if m.in_cat(c)) + '</ul>')
        nav.append('</li>')
    crumb = ' › '.join([f'<a href="{up}index.html">Home</a>'] + [f'<a href="{h}">{esc(t)}</a>' if h else esc(t) for t, h in crumbs])
    # phones: the sidebar collapses, so the current mod's sections get a row of tabs above the page
    tabs = ('<div class="modtabs">' + f'<a href="{up}{mod.id}/index.html">Overview</a>' +
            ''.join(f'<a href="{up}{mod.id}/{c}.html">{t}</a>' for c, t, _ in CATS if mod.in_cat(c)) + '</div>') if mod else ''
    return f'''<!doctype html><html lang="en"><head><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1">
<title>{esc(title)} — Tribes Mod Wiki</title><link rel="stylesheet" href="{up}style.css"></head><body>
<header><a class="logo" href="{up}index.html">Tribes Mod Wiki</a><span class="tag">Starsiege: Tribes (1998) and its mods</span></header>
<div class="wrap"><nav><details open><summary>Browse all mods ({len(MODEL)})</summary><h4>Mods</h4><ul>{''.join(nav)}</ul><h4>Wiki</h4><ul><li><a href="{up}index.html#catalog">Full mod catalog</a></li><li><a href="{up}index.html#reading">Reading the stats</a></li></ul></details></nav>
<main><div class="crumbs">{crumb}</div>{tabs}{body}</main></div>
<footer>Stats are read directly from each mod's game scripts. Generated by build.py.</footer>
<script>if(matchMedia('(max-width:860px)').matches)document.querySelectorAll('nav details,details.grp').forEach(d=>d.open=false)</script></body></html>'''

def table(head, rows, cls='data'):
    h = ''.join(f'<th>{x}</th>' for x in head)
    r = ''.join('<tr>' + ''.join(f'<td>{c}</td>' for c in row) + '</tr>' for row in rows)
    return f'<div class="tw"><table class="{cls}"><thead><tr>{h}</tr></thead><tbody>{r}</tbody></table></div>'

def infobox(title, rows, sub=''):
    r = ''.join(f'<tr><th>{esc(k)}</th><td>{v}</td></tr>' for k, v in rows if v not in (None, '', '—'))
    return f'<aside class="infobox"><div class="ib-title">{esc(title)}</div>{f"<div class=ib-sub>{sub}</div>" if sub else ""}<table>{r}</table></aside>'

def prose(t):
    out = ''
    if t.get('summary'): out += f'<p class="lead">{esc(t["summary"])}</p>'
    if t.get('notes'): out += '<h2>Mechanics</h2><ul>' + ''.join(f'<li>{esc(n)}</li>' for n in t['notes']) + '</ul>'
    if out and t.get('inherited'):
        P = t['inherited']
        src = f'<a href="../{P.id}/index.html">{esc(P.title)}</a>'
        out = (f'<p class="note warn">Write-up borrowed from {src}. This mod changes the item\'s stats, so numbers or details below may not apply here; the Changes table further down shows what differs.</p>'
               if t.get('stale') else f'<p class="note">Same scripts as in {src}; write-up shared with that mod.</p>') + out
    return out

def raw_block(b):
    if not b: return ''
    rows = [(esc(k), esc(fmt(v))) for k, v in b.items() if not k.startswith('_') and not k.startswith(('animData', 'rFoot', 'lFoot'))]
    return f'<details class="raw"><summary>Raw datablock: <code>{b["_type"]} {esc(b["_name"])}</code> <span class="muted">({esc(b["_file"])})</span></summary>{table(["Field", "Value"], rows, "kv")}</details>'


# ---------------------------------------------------------------- per-item stats
def weapon_info(M, it):
    b = M.block(it['name']); img = M.block(b.get('imageType')); proj = M.weapon_proj(it['name'], img)
    rows, blocks = [('Price', fmt(M.num(b.get('price'))))], [b, img, proj]
    if M.glob('TeamItemMax', it['name']) not in (None, ''): rows += [('Team limit', fmt(M.glob('TeamItemMax', it['name'])))]
    if not img: return rows, blocks, None
    ammo = img.get('ammoType')
    rows += [('Ammo', link(M.block(ammo)['_name'], M.block(ammo).get('description')) if M.block(ammo) and M.block(ammo)['_name'] in M.items else (esc(ammo) if ammo else 'Energy'))]
    rows += [('Fire mode', WEAPON_TYPE.get(img.get('weaponType'), '—'))]
    ft, rt = img.get('fireTime', 0) or 0, img.get('reloadTime', 0) or 0
    if ft or rt: rows += [('Fire / reload time', f'{fmt(ft)} s / {fmt(rt)} s')]
    if img.get('spinUpTime'): rows += [('Spin-up', f'{fmt(img["spinUpTime"])} s')]
    if img.get('minEnergy') is not None and not ammo: rows += [('Energy', f'{fmt(img.get("minEnergy"))} min / {fmt(img.get("maxEnergy"))} {"per s" if img.get("weaponType") == 2 else "max"}')]
    dmg = None
    if proj:
        t = proj['_type']
        rows += [('Projectile', f'{esc(proj["_name"])} <span class="muted">({t.replace("Data", "")})</span>')]
        if 'damageValue' in proj:
            dmg = proj['damageValue']; rows += [('Damage', fmt(dmg)), ('Damage type', dtype(proj.get('damageType')))]
        if t == 'LaserData':
            e = img.get('maxEnergy') or 0
            dmg = (proj.get('damageConversion') or 0) * e
            rows += [('Damage', f'{fmt(dmg)} at {fmt(e)} energy <span class="muted">(× {fmt(proj.get("damageConversion"))} per energy)</span>'), ('Damage type', dtype(proj.get('baseDamageType')))]
        if t == 'LightningData':
            rows += [('Damage / s', fmt(proj.get('damagePerSec'))), ('Drains target energy', f'{fmt(proj.get("energyDrainPerSec"))} / s'), ('Beam length', f'{fmt(proj.get("boltLength"))} m'), ('Damage type', dtype(proj.get('damageType')))]
        if t == 'RepairEffectData':
            rows += [('Repair rate', fmt(proj.get('repairRate'))), ('Beam length', fmt(proj.get('boltLength')))]
        if proj.get('explosionRadius'): rows += [('Splash radius', f'{fmt(proj["explosionRadius"])} m')]
        if proj.get('kickBackStrength'): rows += [('Kickback', fmt(proj['kickBackStrength']))]
        if proj.get('muzzleVelocity'): rows += [('Muzzle velocity', f'{fmt(proj["muzzleVelocity"])} m/s' + (f' → {fmt(proj["terminalVelocity"])}' if proj.get('terminalVelocity') else ''))]
        if proj.get('maxLevelFlightDist'): rows += [('Max flight distance', f'{fmt(proj["maxLevelFlightDist"])} m')]
        elif proj.get('muzzleVelocity') and proj.get('totalTime'):
            rows += [('Max travel', f'≈ {fmt(round((proj.get("terminalVelocity") or proj["muzzleVelocity"]) * proj["totalTime"]))} m')]
        if all(isinstance(v, (int, float)) for v in (dmg, ft, rt)) and dmg and (ft + rt) and img.get('weaponType') in (0, 1, 3):
            rows += [('Direct DPS', f'≈ {fmt(dmg / (ft + rt))}')]
    return rows, blocks, (dmg, proj.get('damageType') or proj.get('baseDamageType')) if proj and dmg else None

def kill_table(M, dmg, dt):
    rows = []
    for it, pd, _ in M.armors():
        if not pd: continue
        sc = M.glob('DamageScale', pd['_name'], dt)
        sc = 1.0 if sc is None else sc
        hp, num = pd.get('maxDamage'), (int, float)
        if not (isinstance(dmg, num) and isinstance(sc, num)): continue
        hits = str(math.ceil(round(hp / (dmg * sc), 6))) if sc and dmg and isinstance(hp, num) else '—'
        rows.append([link(it['name'], it['title']), fmt(sc), fmt(dmg * sc), hits])
    if not rows: return ''
    return '<h2>Against each armor</h2><p class="muted">Direct hit / centre of blast, no shield pack. Damage is multiplied by the armor\'s damage scale for this damage type.</p>' + table(['Armor', 'Scale', 'Damage per hit', 'Hits to kill'], rows)

def carriers(M, name):
    rows = []
    for it, pd, _ in M.armors():
        if not pd: continue
        n = M.glob('ItemMax', pd['_name'], name)
        rows.append([link(it['name'], it['title']), '<span class="no">—</span>' if not n else ('✔' if n == 1 else str(n))])
    return '<h2>Carried by</h2>' + table(['Armor', 'Max'], rows) if rows else ''

def armor_info(M, it):
    b = M.block(it['name']); pd = next((p for i, p, _ in M.armors() if i['name'] == it['name']), None)
    fem = next((f for i, _, f in M.armors() if i['name'] == it['name']), None)
    rows = [('Price', fmt(M.num(b.get('price'))))]
    if M.glob('TeamItemMax', it['name']) not in (None, ''): rows += [('Team limit', fmt(M.glob('TeamItemMax', it['name'])))]
    if pd:
        rows += [('Datablock', f'{pd["_name"]}' + (f' / {fem["_name"]} (female)' if fem else '')),
                 ('Health (maxDamage)', fmt(pd.get('maxDamage'))), ('Energy', fmt(pd.get('maxEnergy'))),
                 ('Run speed', f'{fmt(pd.get("maxForwardSpeed"))} m/s'), ('Jet force', fmt(pd.get('jetForce'))),
                 ('Jet energy drain', fmt(pd.get('jetEnergyDrain'))), ('Max jet speed', f'{fmt(pd.get("maxJetForwardVelocity"))} m/s'),
                 ('Mass', fmt(pd.get('mass'))), ('Jump impulse', fmt(pd.get('jumpImpulse'))),
                 ('Weapons carried', fmt(M.glob('MaxWeapons', pd['_name']))), ('Fall damage above', f'{fmt(pd.get("minDamageSpeed"))} m/s')]
    return rows, [b, pd, fem], pd

def loadout(M, pd):
    groups = {}
    for k, v in M.g.get('itemmax', {}).items():
        a, _, item = k.partition(',')
        if a != pd['_name'].lower() or not v: continue
        blk = M.block(item)
        if not blk or blk['_name'] not in M.items: continue
        groups.setdefault(M.items[blk['_name']]['cat'], []).append(f'{link(blk["_name"], M.items[blk["_name"]]["title"])}{"" if v == 1 else f" ×{v}"}')
    if not groups: return ''
    rows = [[CAT_TITLE[c], ', '.join(sorted(groups[c], key=lambda s: re.sub("<.*?>", "", s)))] for c, _, _ in CATS if c in groups]
    return '<h2>Allowed loadout</h2>' + table(['Category', 'Items (max count)'], rows, 'data wide')

def damage_scale(M, name):
    scales = {k.split(',', 1)[1]: v for k, v in M.g.get('damagescale', {}).items() if k.split(',', 1)[0] == name.lower()}
    if not scales: return ''
    scales = {k: M.num(v) for k, v in scales.items()}
    cls = lambda v: '' if not isinstance(v, (int, float)) else 'bad' if v > 1 else 'good' if v < 1 else ''
    rows = [[dtype(k), f'<span class="{cls(v)}">{fmt(v)}</span>'] for k, v in sorted(scales.items())]
    return '<h2>Damage taken</h2><p class="muted">Multiplier on incoming damage by type. Above 1 = weak to it, below 1 = resistant.</p>' + table(['Damage type', 'Scale'], rows)

def vehicle_info(M, it):
    b = M.block(it['name'])
    fl = next((M.block(k) for k, v in M.globs.get('VehicleToItem', {}).items() if str(v).lower() == it['name'].lower()), None)
    rows = [('Price', fmt(M.num(b.get('price')))), ('Team limit', fmt(M.glob('TeamItemMax', it['name'])))]
    if fl:
        proj = M.block(fl.get('projectileType'))
        rows += [('Datablock', fl['_name']), ('Health (maxDamage)', fmt(fl.get('maxDamage'))), ('Energy', fmt(fl.get('maxEnergy'))),
                 ('Max speed', f'{fmt(fl.get("maxSpeed"))} m/s'), ('Accel', fmt(fl.get('accel'))), ('Lift', fmt(fl.get('lift'))),
                 ('Mass', fmt(fl.get('mass'))), ('Ram damage', fmt(fl.get('ramDamage'))),
                 ('Weapon', f'{esc(proj["_name"])} ({fmt(proj.get("damageValue"))} {dtype(proj.get("damageType"))}, every {fmt(fl.get("reloadDelay"))} s)' if proj else 'None (transport)')]
    return rows, [b, fl, M.block(fl.get('projectileType')) if fl else None], fl

def object_rows(M, d):
    """Stats for a deployed/placed object (turret, sensor, station, mine)."""
    rows = [('Health (maxDamage)', fmt(d.get('maxDamage')))]
    if d.get('range') is not None: rows += [('Range', f'{fmt(d["range"])} m')]
    if d.get('maxEnergy'): rows += [('Energy', fmt(d['maxEnergy']))]
    proj = M.block(d.get('projectileType'))
    if proj:
        dv = proj.get('damageValue', proj.get('damagePerSec'))
        rows += [('Fires', esc(proj['_name']) + (f' ({fmt(dv)} {dtype(proj.get("damageType"))})' if dv is not None else '')), ('Reload', f'{fmt(d.get("reloadDelay"))} s' if d.get('reloadDelay') else None)]
    if d['_type'] == 'MineData':
        rows += [('Damage', fmt(d.get('damageValue'))), ('Damage type', dtype(d.get('damageType'))), ('Blast radius', f'{fmt(d.get("explosionRadius"))} m'), ('Trigger radius', f'{fmt(d.get("triggerRadius"))} m'), ('Kickback', fmt(d.get('kickBackStrength')))]
    return rows

def gear_info(M, it):
    b = M.block(it['name']); img = M.block(b.get('imageType'))
    rows = [('Price', fmt(M.num(b.get('price')))), ('Team limit', fmt(M.glob('TeamItemMax', it['name']))), ('Mass', fmt(b.get('mass')))]
    if img and img.get('minEnergy') is not None: rows += [('Energy use', f'{fmt(img.get("minEnergy"))} – {fmt(img.get("maxEnergy"))}')]
    if M.glob('AmmoPackMax', it['name']): rows += [('Ammo pack holds', fmt(M.glob('AmmoPackMax', it['name'])))]
    blocks, deployed = [b, img], []
    for d in M.deploys(it['name']):
        db = M.block(d); deployed.append(db); blocks.append(db)
    return rows, blocks, deployed

def asset_info(M, it):
    b = M.block(it['name'])
    return [('Type', b['_type'].replace('Data', '')), ('Class', esc(b.get('className', '—')))] + object_rows(M, b), [b, M.block(b.get('projectileType'))]


# ---------------------------------------------------------------- base-vs-mod diff
def diff_vs(M, B, blocks):
    rows = []
    for blk in blocks:
        if not blk: continue
        other = B.block(blk['_name'])
        if not other:
            rows.append([f'<code>{esc(blk["_name"])}</code>', f'<span class="muted">not in {esc(B.title)}</span>', 'new'])
            continue
        for k in sorted(set(blk) | set(other)):
            if SKIP_FIELD.match(k): continue
            a, c = other.get(k), blk.get(k)
            if fmt(a) != fmt(c):
                rows.append([f'<code>{esc(blk["_name"])}.{esc(k)}</code>', esc(fmt(a)) if a is not None else '—', esc(fmt(c)) if c is not None else '—'])
    return rows

def item_page(M, it):
    name, cat = it['name'], it['cat']
    t = M.text(name)
    kill = loadout_html = extra = ''
    if cat == 'weapons':
        rows, blocks, d = weapon_info(M, it)
        if d: kill = kill_table(M, *d)
        extra = carriers(M, name)
    elif cat == 'armors':
        rows, blocks, pd = armor_info(M, it)
        if pd: extra = loadout(M, pd) + damage_scale(M, pd['_name'])
    elif cat == 'vehicles':
        rows, blocks, fl = vehicle_info(M, it)
        if fl: extra = damage_scale(M, fl['_name'])
    elif cat == 'base-assets':
        rows, blocks = asset_info(M, it)
    else:
        rows, blocks, deployed = gear_info(M, it)
        for d in deployed:
            extra += f'<h2>Deploys / throws: {esc(d.get("description", d["_name"]))}</h2>' + table(['Stat', 'Value'], [[k, v] for k, v in object_rows(M, d) if v not in (None, '', '—')], 'kv')
        if cat == 'ammo':
            users = [w for w in M.in_cat('weapons') if M.block(M.block(w['name']).get('imageType')) and str(M.block(M.block(w['name']).get('imageType')).get('ammoType', '')).lower() == name.lower()]
            if users: extra += '<h2>Used by</h2><p>' + ', '.join(link(u['name'], u['title']) for u in users) + '</p>'
        extra += carriers(M, name)
    body = f'<h1>{esc(it["title"])}</h1>' + infobox(it['title'], rows, f'{CAT_TITLE[cat]} · <code>{esc(name)}</code>')
    ban = M.ban_status(it)
    if ban == 'banned':
        body += '<p class="note warn">Banned / unavailable at inventory stations in this mod (<code>$InvList</code> / <code>$TeamItemMax = 0</code>).</p>'
    elif ban == 'main-only':
        body += '<p class="note">Main base Inventory Stations only (<code>$RemoteInvList = 0</code>).</p>'
    elif ban == 'remote-only':
        body += '<p class="note">Remote deployable stations only (<code>$InvList = 0</code>).</p>'
    body += prose(t) or '<p class="lead muted">No write-up yet. Stats below come straight from the scripts.</p>'
    body += kill + extra
    if getattr(M, 'base', None):
        B = BY_ID[M.base]
        drows = diff_vs(M, B, blocks)
        bi = B.items.get(name)
        head = f'<h2>Changes from {esc(B.title)}</h2>'
        if bi: head += f'<p>Same datablock as {B.title}\'s <a href="../{B.id}/{slug(name)}.html">{esc(bi["title"])}</a>.</p>'
        body += head + (table(['Field', B.title, M.title], drows) if drows else '<p class="muted">Identical to base.</p>')
    others = [m for m in MODEL if m is not M and name in m.items]
    if others:
        body += '<h2>In other mods</h2><ul>' + ''.join(f'<li><a href="../{m.id}/{slug(name)}.html">{esc(m.title)}: {esc(m.items[name]["title"])}</a></li>' for m in others) + '</ul>'
    body += '<h2>Script data</h2>' + ''.join(raw_block(b) for b in blocks if b)
    return shell(it['title'], body, M, [(M.title, 'index.html'), (CAT_TITLE[cat], f'{cat}.html'), (it['title'], None)])


# ---------------------------------------------------------------- category & mod pages
def summary_row(M, it):
    cat, name = it['cat'], it['name']
    if cat == 'weapons':
        rows = dict(weapon_info(M, it)[0])
        return [rows.get('Price', ''), rows.get('Ammo', ''), rows.get('Damage', rows.get('Damage / s', '')), rows.get('Damage type', ''), rows.get('Splash radius', ''), rows.get('Direct DPS', '')]
    if cat == 'armors':
        rows = dict(armor_info(M, it)[0])
        return [rows.get('Price', ''), rows.get('Health (maxDamage)', ''), rows.get('Energy', ''), rows.get('Run speed', ''), rows.get('Jet force', ''), rows.get('Weapons carried', '')]
    if cat == 'vehicles':
        rows = dict(vehicle_info(M, it)[0])
        return [rows.get('Price', ''), rows.get('Team limit', ''), rows.get('Health (maxDamage)', ''), rows.get('Max speed', ''), rows.get('Weapon', '')]
    if cat == 'base-assets':
        rows = dict(asset_info(M, it)[0])
        return [rows.get('Type', ''), rows.get('Health (maxDamage)', ''), rows.get('Range', ''), rows.get('Fires', '')]
    rows, _, dep = gear_info(M, it)
    rows = dict(rows)
    return [rows.get('Price', ''), rows.get('Team limit', ''), ', '.join(dict.fromkeys(esc(d.get('description', d['_name'])) for d in dep))]

SUMMARY_HEAD = {
    'weapons': ['Price', 'Ammo', 'Damage', 'Type', 'Splash', 'DPS'],
    'armors': ['Price', 'Health', 'Energy', 'Run', 'Jet', 'Weapons'],
    'vehicles': ['Price', 'Limit', 'Health', 'Speed', 'Weapon'],
    'base-assets': ['Type', 'Health', 'Range', 'Fires'],
}

def cat_table(M, cat):
    items = M.in_cat(cat)
    head = ['Name'] + SUMMARY_HEAD.get(cat, ['Price', 'Team limit', 'Deploys'])
    rows = [[link(i['name'], i['title']) + (' <span class="muted">(banned)</span>' if M.ban_status(i) == 'banned' else '')] + summary_row(M, i) for i in items]
    return table(head, rows)

def loadout_matrix(M, cat):
    arm = [(it, pd) for it, pd, _ in M.armors() if pd]
    rows = []
    for i in M.in_cat(cat):
        cells = [M.glob('ItemMax', pd['_name'], i['name']) for _, pd in arm]
        if not any(cells): continue
        rows.append([link(i['name'], i['title'])] + ['<span class="no">·</span>' if not c else ('✔' if c == 1 else str(c)) for c in cells])
    if not rows: return ''
    return f'<h2>Who can carry what</h2>' + table([''] + [link(it['name'], it['title']) for it, _ in arm], rows, 'data matrix')

def cat_page(M, cat):
    intro = M.content.get('categories', {}).get(cat, '')
    body = f'<h1>{esc(M.title)}: {CAT_TITLE[cat]}</h1>' + (f'<p class="lead">{esc(intro)}</p>' if intro else '')
    body += cat_table(M, cat)
    if cat == 'armors':
        arm = [(it, pd) for it, pd, _ in M.armors() if pd]
        types = sorted({k.split(',', 1)[1] for k in M.g.get('damagescale', {}) if k.split(',', 1)[0] in {pd['_name'].lower() for _, pd in arm}})
        rows = [[dtype(t)] + [fmt(M.glob('DamageScale', pd['_name'], t) or '—') for _, pd in arm] for t in types]
        body += '<h2>Damage taken by type</h2>' + table(['Type'] + [link(it['name'], it['title']) for it, _ in arm], rows, 'data matrix')
    elif cat != 'base-assets':
        body += loadout_matrix(M, cat)
    return shell(f'{M.title} {CAT_TITLE[cat]}', body, M, [(M.title, 'index.html'), (CAT_TITLE[cat], None)])

def mod_page(M):
    c = M.content.get('mod', {})
    rows = [('Version', M.version), ('Author', esc(M.author)), ('Era', M.era), ('Launch', f'<code>{esc(M.launch)}</code>' if M.launch else '')]
    rows += [(CAT_TITLE[k], str(len(M.in_cat(k)))) for k, _, _ in CATS if M.in_cat(k)]
    body = f'<h1>{esc(M.title)} {esc(M.version)}</h1>' + infobox(M.title, rows)
    if c.get('overview'): body += f'<p class="lead">{esc(c["overview"])}</p>'
    if c.get('notes'): body += '<h2>Key mechanics</h2><ul>' + ''.join(f'<li>{esc(n)}</li>' for n in c['notes']) + '</ul>'
    for k, t, _ in CATS:
        if M.in_cat(k): body += f'<h2 id="{k}"><a href="{k}.html">{t}</a></h2>' + cat_table(M, k)
    return shell(M.title, body, M, [(M.title, None)])

def home():
    cat = json.load(open(os.path.join(ROOT, 'content', 'catalog.json'), encoding='utf-8'))
    doc = {m.id: m for m in MODEL}
    def card(m):
        return (f'<a class="card" href="{m.id}/index.html"><b>{esc(m.title)} {esc(m.version)}</b><span>{len(m.items)} pages · ' +
                ', '.join(f'{len(m.in_cat(k))} {t.lower()}' for k, t, _ in CATS[:4] if m.in_cat(k)) + '</span></a>')
    cards = '<div class="cards">' + ''.join(card(m) for m in MODEL if not getattr(m, 'group', None)) + '</div>'
    for g in dict.fromkeys(m.group for m in MODEL if getattr(m, 'group', None)):
        ms = [m for m in MODEL if getattr(m, 'group', None) == g]
        cards += (f'<details class="grp" open><summary>{esc(g)} <span class="muted">({len(ms)})</span></summary><div class="cards">'
                  + ''.join(card(m) for m in ms) + '</div></details>')
    groups = {}
    for e in cat: groups.setdefault(e['category'], []).append(e)
    cat_html = ''
    for g, es in groups.items():
        rows = [[(f'<a href="{e["id"]}/index.html"><b>{esc(e["title"])}</b></a> <span class="pill">documented</span>' if e['id'] in doc else esc(e['title'])),
                 esc(e['author']), esc(e['era']), f'<code>{esc(e["launch"])}</code>' if e['launch'] else ''] for e in es]
        cat_html += (f'<details class="grp" open><summary>{esc(g)} <span class="muted">({len(es)})</span></summary>'
                     + table(['Mod', 'Author', 'Era', 'Launch'], rows) + '</details>')
    body = f'''<h1>Tribes Mod Wiki</h1>
<p class="lead">A reference for <i>Starsiege: Tribes</i> (1998) and its server mods: every armor, weapon, pack, deployable and vehicle, with stats pulled straight from each mod's scripts. Start with base Tribes, then see how each mod changes it.</p>
<h2>Documented mods</h2>{cards}
<h2 id="reading">Reading the stats</h2>
<ul><li><b>Health</b> is an armor's <code>maxDamage</code>. A weapon's <b>damage</b> is subtracted from it after the armor's <b>damage scale</b> for that damage type (e.g. heavy armor takes 0.6× bullet damage).</li>
<li><b>Hits to kill</b> assume a direct hit or the centre of a blast. Splash damage falls off with distance from the explosion.</li>
<li><b>Fire / reload time</b> are seconds per shot; <b>DPS</b> is damage ÷ (fire + reload) on a direct hit.</li>
<li>Mod pages list <b>Changes from Base Tribes</b>, field by field, wherever a mod reuses a stock datablock.</li>
<li>Every page ends with the raw datablocks so modders can check the source values.</li></ul>
<h2 id="catalog">Mod catalog</h2><p>All {len(cat)} mods from the Tribes Asset Store and Krogoth's File Library. Mods marked <span class="pill">documented</span> have full pages; the rest are listed for reference.</p>{cat_html}'''
    return shell('Home', body, None, (), depth=0)


# ---------------------------------------------------------------- main
def write(path, html):
    os.makedirs(os.path.dirname(path), exist_ok=True)
    open(path, 'w', encoding='utf-8').write(html)

def main():
    global MODEL, BY_ID
    MODEL = [Mod(m) for m in MODS]
    BY_ID = {m.id: m for m in MODEL}
    for M in MODEL:
        M.changed = changed(M, BY_ID[M.base]) if getattr(M, 'base', None) else {}
    os.makedirs(OUT, exist_ok=True)
    for e in os.scandir(OUT):  # empty it rather than delete it: a preview server or Explorer window may hold site/ open
        shutil.rmtree(e.path) if e.is_dir() else os.remove(e.path)
    shutil.copy(os.path.join(ROOT, 'style.css'), OUT)
    write(os.path.join(OUT, 'index.html'), home())
    n = 1
    for M in MODEL:
        d = os.path.join(OUT, M.id)
        write(os.path.join(d, 'index.html'), mod_page(M)); n += 1
        for c, _, _ in CATS:
            if M.in_cat(c): write(os.path.join(d, f'{c}.html'), cat_page(M, c)); n += 1
        for it in M.items.values():
            write(os.path.join(d, f'{slug(it["name"])}.html'), item_page(M, it)); n += 1
        missing = [i['name'] for i in M.items.values() if i['cat'] not in ('ammo', 'base-assets') and not M.text(i['name'])]
        print(f'{M.id}: {len(M.items)} items' + (f'; no write-up: {", ".join(missing)}' if missing else ''))
    print(f'{n} pages -> {OUT}')

if __name__ == '__main__':
    main()
