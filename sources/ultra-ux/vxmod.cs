
$modInfo = "\n<f1>" @ $Ultra_RenegadesUX::ultravxmod @ "\n<f2>For Extreme Players/UltraUX";

//"<f1>Ultra_RenegadesUX The Ultra Extreme Mod\n"@

function vxmode(%mode){

$Ultra_RenegadesUX::ultravxmod = %mode;
%mode = $Ultra_RenegadesUX::ultravxmod;

 
if(%mode == "Ultra_RenegadesUX"){
exec("Ultra_RenegadesUX.cs");
echo("Changing UltraVX MOD... " @ $Ultra_RenegadesUX::ultravxmod @ " loading...");
$modInfo = "\n<f1>Mod: <f2>" @ $Ultra_RenegadesVX5::ultravxmod @ "\n<f1>Difficulty Mode: <f2>" @ $Ultra_RenegadesVX5::ultravxDIFmode @ "\n\n<f2>PlanetTribes.com/UltraVX";
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
remoteEval(%cl, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
remoteEval(%cl, MODInfo, $MODInfo);
bottomprintall("<jc><f0>Server is now running: <f1>" @ $Ultra_RenegadesVX5::ultravxmod @ "<f0> MOD\nDifficulty mode: <f1>" @ $Ultra_RenegadesVX5::ultravxDIFmode @ "\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 7);
                   }

if(%mode == "Ultra_RenegadesVX5_OGL"){
exec("UltraVX5_OGL.cs");
echo("Changing UltraVX MOD... " @ $Ultra_RenegadesVX5::ultravxmod @ " loading...");
$modInfo = "\n<f1>Mod: <f2>" @ $Ultra_RenegadesVX5::ultravxmod @ "\n<f1>Difficulty Mode: <f2>" @ $Ultra_RenegadesVX5::ultravxDIFmode @ "\n\n<f2>PlanetTribes.com/UltraVX";
//$modInfo = "\n<f1>" @ $ultravxmod @ "\n<f2>PlanetTribes.com/UltraVX";
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
remoteEval(%cl, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
remoteEval(%cl, MODInfo, $MODInfo);
bottomprintall("<jc><f0>Server is now running: <f1>" @ $Ultra_RenegadesVX5::ultravxmod @ "<f0> MOD\nDifficulty mode: <f1>" @ $Ultra_RenegadesVX5::ultravxDIFmode @ "\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 7);
                   }

if(%mode == "Ultra_RenegadesUX_NOTOR"){
exec("UltraUX_NOTOR.cs");
echo("Changing UltraVX MOD... " @ $Ultra_RenegadesVX5::ultravxmod @ " loading...");
$modInfo = "\n<f1>Mod: <f2>" @ $Ultra_RenegadesVX5::ultravxmod @ "\n<f1>Difficulty Mode: <f2>" @ $Ultra_RenegadesVX5::ultravxDIFmode @ "\n\n<f2>PlanetTribes.com/UltraVX";
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
remoteEval(%cl, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
remoteEval(%cl, MODInfo, $MODInfo);
bottomprintall("<jc><f0>Server is now running: <f1>" @ $Ultra_RenegadesVX5::ultravxmod @ "<f0> MOD\nDifficulty mode: <f1>" @ $Ultra_RenegadesVX5::ultravxDIFmode @ "\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 7);
                  }
export("Ultra_RenegadesVX5::*", "config\\Ultra_RenegadesVX5.cs", False);
}

function vxDIFmode(%mode){
   $UltraUX::ultravxDIFmode = %mode;
   %mode = $UltraUX::ultravxDIFmode;
   
   if(%mode == "Defaults")
     {
      exec("UltraVX5_EASY.cs");
      //echo("Changing UltraVX MOD... " @ $UltraUX::ultravxDIFmode @ " loading...");
     }
   if(%mode == "MEDIUM")
     {
      exec("UltraVX5_MEDIUM.cs");
     // echo("Changing UltraVX MOD... " @ $Ultra_RenegadesVX5::ultravxDIFmode @ " loading...");
     }
   if(%mode == "HARD")
     {
      exec("UltraVX5_HARD.cs");
     // echo("Changing UltraVX MOD... " @ $Ultra_RenegadesVX5::ultravxDIFmode @ " loading...");
     }
bottomprintall("<jc><f0>Server is now running: <f1>" @ $Ultra_RenegadesUX::ultravxmod @ "<f0> MOD\nDifficulty mode: <f1>" @ $Ultra_RenegadesUX::ultravxDIFmode @ "\n<f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 7);
echo("Changing UltraUX MODE... Difficulty Mode: " @ $Ultra_RenegadesVX5::ultravxDIFmode @ " loading...");
export("Ultra_RenegadesVX5::*", "config\\Ultra_RenegadesVX5.cs", False);
}

