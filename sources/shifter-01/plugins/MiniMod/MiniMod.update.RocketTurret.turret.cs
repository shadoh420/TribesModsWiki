// This is a MiniMod Plugin.
// This plugin will bring any old mod's base RocketTurret up to date.
// No More mods that disable your Main Rocket Turrets. :)
// Just run them with MiniMod and your all set to go. :)

function RocketTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

