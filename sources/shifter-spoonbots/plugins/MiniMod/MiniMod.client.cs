// This is a MiniMod Plugin.
// This is MiniMod's set of "Mission Loading" messages.

function dataGotBlock(%blockName, %pctDone)
{
MiniMod::Load("plugins\\*.BanList.cs");
   if(%pctDone < 0.1)
      %text = "Loading Functions...";
   else if(%pctDone < 0.2)
      %text = "Loading Plugins...";
   else if(%pctDone < 0.3)
      %text = "Assigning Items, Weapons and Armor Loadouts...";
   else if(%pctDone < 0.4)
      %text = "Welcome to this MiniMod v.07 enhanced Server...";
   else if(%pctDone < 0.5)
      %text = "You can download MiniMod from...";
   else if(%pctDone < 0.6)
      %text = "http://www.PlanetStarSiege.com/minimod";
   else if(%pctDone < 0.7)
      %text = "Joining curret mission...";
   else if(%pctDone < 0.8)
      %text = "Note: MiniMod servers are often EXTREAMLY modified...";
   else
      %text = "Enjoy your game...";

   //Control::setText(ProgressText, "Loading " @ %blockName @ " data...");
   Control::setValue(ProgressText, "<jc><f1>" @ %text);
   Control::setValue(ProgressSlider, %pctDone * 0.75);
}
