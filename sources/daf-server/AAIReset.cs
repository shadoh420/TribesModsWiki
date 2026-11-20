function AAI::getFirst()
{
	return BaseRep::getFirst();
}

function AAI::getNext(%cl)
{
	return BaseRep::getNext(%cl);
}


function AAI::OnFire()
{}

function AAI::GrenadeExplodes(%grenade)
{}

function AAI::GrenadeThrown(%grenade)
{}

function AAI::TrackGrenade(%grenade)
{}

function AAI::onFire(%this,%vec,%silent)
{}

function AAI::WasShotReaction(%this,%shooter)
{}

function AAI::SpecialScanCases(%clientId)
{
return true;
}

function AAI::AddToStats(%clientId, %stat)
{}

$AAI::GoSuicidal = 0;

$AAI::ParadropMission = 0;
$AAI::StatsGame = 0;

AAI::ResetStats();