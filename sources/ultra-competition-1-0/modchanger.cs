// in game mod changer by {187}George W.

exec("league.cs");
exec("ve.cs");
exec("notor.cs");
exec("jimsmod.cs");
if(!$Server::Mod) $Server::Mod=1;
function LoadMod()
{
	if($Server::Mod==1)
	{
		veOFF();
		notorOFF();
		vx4aOFF();
		leagueON();
		Server::NextMission(true);
	}
	else if($Server::Mod==2)
	{
		leagueOFF();
		notorOFF();
		vx4aOFF();
		veON();
		Server::NextMission(true);
	}
	else if($Server::Mod==3)
	{
		leagueOFF();
		veOFF();
		vx4aOFF();
		notorON();
		Server::NextMission(true);
	}
	else if($Server::Mod==4)
	{
		leagueOFF();
		veOFF();
		notorOFF();
		vx4aON();
		Server::NextMission(true);
	}
	else
		echo("Unsupported mod ("@$Server::Mod@") attempted.");
	for(%i=client::getfirst(); %i!=-1; %i=client::getnext(%i))
		remoteEval(%i, SVInfo, version(), $Server::Hostname, $modlist, $Server::Info, $ItemFavoritesKey);
	return;
}
$modlist="Ultra_Competition (League)";
if($Server::Mod!=1) LoadMod();